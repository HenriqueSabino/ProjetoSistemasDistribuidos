from rest_framework import viewsets

from inventory.api.v1.serializers.city import CitySerializer
from inventory.models.city import City


class CityViewSet(viewsets.ModelViewSet):
    queryset = City.objects.all()
    serializer_class = CitySerializer
