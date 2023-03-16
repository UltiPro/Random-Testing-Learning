from django.urls import path

from . import views

urlpatterns = [
    path("", views.review),
    path("ty", views.ty)
]
