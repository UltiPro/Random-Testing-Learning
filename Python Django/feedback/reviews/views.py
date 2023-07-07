from django.shortcuts import render
from django.http import HttpResponseRedirect
from django.views import View
from django.views.generic.base import TemplateView
from django.views.generic import ListView, DetailView
from django.views.generic.edit import FormView, CreateView, UpdateView, DeleteView

from .forms import ReviewForm
from .models import Review

# Create your views here.


class ReviewView(CreateView): #FormView
    model = Review # dla create 
    #fields = "__all__" # dla create 
    form_class = ReviewForm
    template_name = "reviews/review.html"
    success_url = "/ty"

    #def form_valid(self, form):
    #    form.save()
    #    return super().form_valid(form)

    '''def get(self, request):
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
        })'''


class TYView(TemplateView):
    template_name = "reviews/ty.html"

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context["message"] = "tak mordo"
        return context
    # def get(self, request):
    #    return render(request, "reviews/ty.html")


class ReviewsListView(ListView):
    template_name = "reviews/review_list.html"
    model = Review
    context_object_name = "reviews"

    def get_queryset(self):
        base = super().get_queryset()
        return base.filter(rating__gt=4)


class SingleReviewView(DetailView):
    template_name = "reviews/single_review.html"
    model = Review


'''def review(request):
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
    return render(request, "reviews/ty.html")'''
