from rest_framework import serializers

from inventory.models import output


class OutputSerializer(serializers.ModelSerializer):
    class Meta:
        model = output.Output

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
