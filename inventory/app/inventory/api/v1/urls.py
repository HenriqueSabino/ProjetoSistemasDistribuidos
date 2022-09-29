from django.urls import path, include
from rest_framework.routers import SimpleRouter

from inventory.api.v1.views import (
    category,
    city,
    entry_item,
    entry,
    output_item,
    output,
    product,
    provider,
    shipping_company,
    store,
)


router = SimpleRouter()
router.register('categories', category.CategoryViewSet, 'category')
router.register('cities', city.CityViewSet, 'city')
router.register('entry_items', entry_item.EntryItemViewSet, 'entry_item')
router.register('entries', entry.EntryViewSet, 'entry')
router.register('output_items', output_item.OutputItemViewSet, 'output_item')
router.register('outputs', output.OutputViewSet, 'ouput')
router.register('products', product.ProductViewSet, 'product')
router.register('providers', provider.ProviderViewSet, 'provider')
router.register('shipping_companies', shipping_company.ShippingCompanyViewSet, 'shipping_company')
router.register('stores', store.StoreViewSet, 'store')


app_name = 'inventory'

urlpatterns = [
    path('', include(router.urls)),
]
