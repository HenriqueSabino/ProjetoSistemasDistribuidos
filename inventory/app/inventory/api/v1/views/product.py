from rest_framework import viewsets

from inventory.api.v1.serializers.product import ProductSerializer
from inventory.models.product import Product


class ProductViewSet(viewsets.ModelViewSet):
    queryset = Product.objects.all()
    serializer_class = ProductSerializer
