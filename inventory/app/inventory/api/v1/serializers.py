"""
Serializers for the API View.
"""
from rest_framework import serializers

from inventory.models import (
    Product,
    Order,
)


class ProductSerializer(serializers.ModelSerializer):
    """Serializer for the product object."""

    class Meta:
        model = Product
        fields = '__all__'
        read_only_fields = (
            'id',
            'created_at',
        )


class OrderSerializer(serializers.ModelSerializer):
    """Serializer for the order object."""

    class Meta:
        model = Order
        fields = '__all__'
        read_only_fields = (
            'id',
            'created_at',
        )
