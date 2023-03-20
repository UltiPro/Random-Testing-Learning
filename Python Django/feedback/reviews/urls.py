from django.urls import path

from . import views

urlpatterns = [
    path("", views.ReviewView.as_view()),
    path("ty", views.TYView.as_view()),
    path("reviews", views.ReviewsListView.as_view()),
    path("reviews/<int:id>", views.SingleReviewView.as_view())
]
