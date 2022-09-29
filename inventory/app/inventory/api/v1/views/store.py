from rest_framework import viewsets

from inventory.api.v1.serializers.store import StoreSerializer
from inventory.models.store import Store


class StoreViewSet(viewsets.ModelViewSet):
    queryset = Store.objects.all()
    serializer_class = StoreSerializer
