from django.db import models

from inventory.models import category, provider


class Product(models.Model):
    category = models.ForeignKey(category.Category, on_delete=models.CASCADE)
    provider = models.ForeignKey(provider.Provider, on_delete=models.CASCADE)
    description = models.TextField(max_length=400)
    created_at = models.DateTimeField(auto_now_add=True)
