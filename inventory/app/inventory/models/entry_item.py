from django.db import models

from inventory.models import entry, product


class EntryItem(models.Model):
    entry = models.ForeignKey(entry.Entry, on_delete=models.CASCADE)
    product = models.ForeignKey(product.Product, on_delete=models.CASCADE)
    quantity = models.IntegerField()
    value = models.FloatField()
    created_at = models.DateTimeField(auto_now_add=True)
