from rest_framework import serializers

from inventory.models import entry


class EntrySerializer(serializers.ModelSerializer):
    class Meta:
        model = entry.Entry

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
