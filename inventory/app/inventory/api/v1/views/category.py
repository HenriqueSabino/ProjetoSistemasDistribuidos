from rest_framework import viewsets

from inventory.api.v1.serializers.category import CategorySerializer
from inventory.models.category import Category


class CategoryViewSet(viewsets.ModelViewSet):
    queryset = Category.objects.all()
    serializer_class = CategorySerializer
