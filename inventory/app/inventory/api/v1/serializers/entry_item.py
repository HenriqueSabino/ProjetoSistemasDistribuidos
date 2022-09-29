from rest_framework import serializers

from inventory.models import entry_item


class EntryItemSerializer(serializers.ModelSerializer):
    class Meta:
        model = entry_item.EntryItem

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
