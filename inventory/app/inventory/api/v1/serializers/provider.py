from rest_framework import serializers

from inventory.models import provider


class ProviderSerializer(serializers.ModelSerializer):
    class Meta:
        model = provider.Provider

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
