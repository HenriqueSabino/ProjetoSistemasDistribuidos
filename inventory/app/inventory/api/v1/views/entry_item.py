from rest_framework import viewsets

from inventory.api.v1.serializers.entry_item import EntryItemSerializer
from inventory.models.entry_item import EntryItem


class EntryItemViewSet(viewsets.ModelViewSet):
    queryset = EntryItem.objects.all()
    serializer_class = EntryItemSerializer
