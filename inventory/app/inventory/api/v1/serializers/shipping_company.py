from rest_framework import serializers

from inventory.models import shipping_company


class ShippingCompanySerializer(serializers.ModelSerializer):
    class Meta:
        model = shipping_company.ShippingCompany

        fields = '__all__'

        read_only_fields = (
            'id',
            'created_at',
        )
