from rest_framework import viewsets

from inventory.api.v1.serializers.provider import ProviderSerializer
from inventory.models.provider import Provider


class ProviderViewSet(viewsets.ModelViewSet):
    queryset = Provider.objects.all()
    serializer_class = ProviderSerializer
