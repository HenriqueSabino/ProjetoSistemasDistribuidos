from rest_framework import viewsets

from inventory.api.v1.serializers.output_item import OutputItemSerializer
from inventory.models.output_item import OutputItem


class OutputItemViewSet(viewsets.ModelViewSet):
    queryset = OutputItem.objects.all()
    serializer_class = OutputItemSerializer
