from rest_framework import serializers

from inventory.models import output_item


class OutputItemSerializer(serializers.ModelSerializer):
    class Meta:
        model = output_item.OutputItem

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
