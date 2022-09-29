from rest_framework import serializers

from inventory.models import city


class CitySerializer(serializers.ModelSerializer):
    class Meta:
        model = city.City

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
