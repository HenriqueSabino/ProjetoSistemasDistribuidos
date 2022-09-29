from rest_framework import viewsets

from inventory.api.v1.serializers.entry import EntrySerializer
from inventory.models.entry import Entry


class EntryViewSet(viewsets.ModelViewSet):
    queryset = Entry.objects.all()
    serializer_class = EntrySerializer
