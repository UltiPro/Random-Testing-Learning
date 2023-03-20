from django.shortcuts import render
from django.http import HttpResponseRedirect
from django.views import View

from .forms import ReviewForm
from .models import Review

# Create your views here.


class ReviewView(View):
    def get(self, request):
        form = ReviewForm()
        return render(request, "reviews/review.html", {
            "form": form
        })

    def post(self, request):
        form = ReviewForm(request.POST)
        if form.is_valid():
            form.save()
            return HttpResponseRedirect("/ty")
        return render(request, "reviews/review.html", {
            "form": form
        })


def review(request):
    if request.method == "POST":
        exisitng_data = Review.objects.get(pk=1)
        form = ReviewForm(request.POST, instance=exisitng_data)
        if form.is_valid():
            print(form.cleaned_data)
            # review = Review(user_name = form.cleaned_data['user_name'],
            #                review_text = form.cleaned_data['review_text'],
            #                rating = form.cleaned_data['rating'])
            # review.save()
            form.save()
            return HttpResponseRedirect("/ty")
    else:
        form = ReviewForm()

    return render(request, "reviews/review.html", {
        "form": form
    })


def ty(request):
    return render(request, "reviews/ty.html")
