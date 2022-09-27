from django.db import models

from inventory.models import output, product


class OutputItem(models.Model):
    output = models.ForeignKey(output.Output, on_delete=models.CASCADE)
    product = models.ForeignKey(product.Product, on_delete=models.CASCADE)
    parcel = models.IntegerField()
    quantity = models.IntegerField()
    value = models.FloatField()
    created_at = models.DateTimeField(auto_now_add=True)
