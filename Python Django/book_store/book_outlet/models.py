from django.db import models

# Create your models here.

class Book(models.Model):
    # id jest dodawane automatycznie
    title = models.CharField(max_length=50)
    rating = models.IntegerField()
