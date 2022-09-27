from rest_framework import serializers

from inventory.models import category


class Category(serializers.ModelSerializer):
    class Meta:
        model = category.Category

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
