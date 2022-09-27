from django.db import models


class City(models.Model):
    name = models.CharField(max_length=50)
    federative_unit = models.CharField(max_length=2)
    created_at = models.DateTimeField(auto_now_add=True)
