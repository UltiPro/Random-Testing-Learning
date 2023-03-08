from django.shortcuts import render
from django.http import HttpResponse, HttpResponseNotFound, HttpResponseRedirect
from django.urls import reverse

# Create your views here.

month_list = {
    "january": "Hello january",
    "february": "Hello february",
    "march": "Hello march",
    "may": "Hello may",
}


# def january(request):
#    return HttpResponse("Hello january!")


# def february(request):
#    return HttpResponse("Hello february!")


def monthly_challange(request, month):
    '''match month:
        case "january":
            return HttpResponse("Hello {}!".format(month))
        case "february":
            return HttpResponse("Hello {}!".format(month))
        case _:
            return HttpResponseNotFound("Not supported")'''
    try:
        output = month_list[month]
        return HttpResponse(output)
    except:
        return HttpResponseNotFound("Not supported")


def monthly_challange_by_number(request, month):
    month_keys = list(month_list.keys())
    if month > len(month_list):
        return HttpResponseNotFound("Invalid number")
    forward = month_keys[month - 1]
    redirect_path = reverse("month-challenge", args=[forward])
    return HttpResponseRedirect(redirect_path)
