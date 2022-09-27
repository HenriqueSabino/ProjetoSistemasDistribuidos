from django.db import models

from inventory.models import shipping_company


class Entry(models.Model):
    shipping_company = models.ForeignKey(
        shipping_company.ShippingCompany,
        on_delete=models.CASCADE
    )
    total = models.FloatField()
    shipping = models.FloatField()
    created_at = models.DateTimeField(auto_now_add=True)
