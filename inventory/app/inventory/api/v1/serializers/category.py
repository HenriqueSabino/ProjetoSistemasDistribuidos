from rest_framework import serializers

from inventory.models import category


class CategorySerializer(serializers.ModelSerializer):
    class Meta:
        model = category.Category

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
