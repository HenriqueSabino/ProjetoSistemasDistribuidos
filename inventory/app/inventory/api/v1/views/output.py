from rest_framework import viewsets

from inventory.api.v1.serializers.output import OutputSerializer
from inventory.models.output import Output


class OutputViewSet(viewsets.ModelViewSet):
    queryset = Output.objects.all()
    serializer_class = OutputSerializer
