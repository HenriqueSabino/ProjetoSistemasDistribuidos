from rest_framework import serializers

from inventory.models import product


class ProductSerializer(serializers.ModelSerializer):
    class Meta:
        model = product.Product

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
