from django.shortcuts import render
from django.http import HttpResponse, HttpResponseNotFound, HttpResponseRedirect, Http404
from django.urls import reverse
#from django.template.loader import render_to_string

# Create your views here.

month_list = {
    "january": "Hello january",
    "february": "Hello february",
    "march": "Hello march",
    "may": None
}


# def january(request):
#    return HttpResponse("Hello january!")


# def february(request):
#    return HttpResponse("Hello february!")

def index(request):
    list_items = ''
    months = list(month_list.keys())

    return render(request, "challenges/index.html", {
        "months": months
    })

    '''for month in months:
        cap_month = month.capitalize()
        month_path = reverse("month-challenge", args=[month])
        list_items += f"<li><a href=\"{month_path}\">{cap_month}</a></li>"

    return HttpResponse(list_items)'''


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
        return render(request, "challenges/challenge.html", {  # dictionary
            "output": output,
            "month": month
        })
        # response = render_to_string("challenges/challenge.html")
        # return HttpResponse(response)
    except:
        #res_data = render_to_string("404.html")
        #return HttpResponseNotFound(res_data)
        raise Http404()


def monthly_challange_by_number(request, month):
    month_keys = list(month_list.keys())
    if month > len(month_list):
        return HttpResponseNotFound("Invalid number")
    forward = month_keys[month - 1]
    redirect_path = reverse("month-challenge", args=[forward])
    return HttpResponseRedirect(redirect_path)
