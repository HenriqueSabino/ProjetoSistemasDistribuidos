from rest_framework import viewsets

from inventory.api.v1.serializers.shipping_company import ShippingCompanySerializer
from inventory.models.shipping_company import ShippingCompany


class ShippingCompanyViewSet(viewsets.ModelViewSet):
    queryset = ShippingCompany.objects.all()
    serializer_class = ShippingCompanySerializer
