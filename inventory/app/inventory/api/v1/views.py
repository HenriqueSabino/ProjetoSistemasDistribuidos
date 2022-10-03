from rest_framework import viewsets

from inventory.api.v1.serializers import ProductSerializer, OrderSerializer
from inventory.models import (
    Product,
    Order,
)


class ProductView(viewsets.ModelViewSet):
    queryset = Product.objects.all()
    serializer_class = ProductSerializer


class OrderView(viewsets.ModelViewSet):
    queryset = Order.objects.all()
    serializer_class = OrderSerializer
