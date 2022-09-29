from rest_framework import serializers

from inventory.models import store


class StoreSerializer(serializers.ModelSerializer):
    class Meta:
        model = store.Store

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
