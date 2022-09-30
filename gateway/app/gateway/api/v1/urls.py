from django.urls import path

from gateway.api.v1.views import (
    category,
)

app_name = 'gateway'

urlpatterns = [
    path('categories/', category.CategoryAPIView.as_view(), name='category'),
]
