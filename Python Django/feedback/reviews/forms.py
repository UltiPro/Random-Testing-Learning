from django import forms

class ReviewForm(forms.Form):
    name = forms.CharField(min_length=3, max_length=100, label="name2323", error_messages={ # required = False/True
        "required": "tak",
        "max_length": "nie"
    })