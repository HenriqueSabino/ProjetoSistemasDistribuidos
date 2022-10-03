from django.urls import path, include
from rest_framework.routers import SimpleRouter

from inventory.api.v1 import views


router = SimpleRouter()
router.register('products', views.ProductView, 'product')
router.register('orders', views.OrderView, 'order')

app_name = 'inventory'

urlpatterns = [
    path('', include(router.urls)),
]
