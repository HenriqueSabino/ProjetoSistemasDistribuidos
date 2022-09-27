from django.db import models

from inventory.models import shipping_company, store


class Output(models.Model):
    store = models.ForeignKey(
        store.Store,
        on_delete=models.CASCADE
    )
    shipping_company = models.ForeignKey(
        shipping_company.ShippingCompany,
        on_delete=models.CASCADE
    )
    total = models.FloatField()
    shipping = models.FloatField()
    created_at = models.DateTimeField(auto_now_add=True)
