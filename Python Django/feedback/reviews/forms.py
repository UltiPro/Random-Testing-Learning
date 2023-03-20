from django import forms

from .models import Review

#class ReviewForm(forms.Form):
#    name = forms.CharField(min_length=3, max_length=100, label="name2323", error_messages={ # required = False/True
#        "required": "tak",
#        "max_length": "nie"
#   })
#    review_text = forms.CharField(label="tak 2", widget=forms.Textarea, max_length=1000)
#    rating = forms.IntegerField(label="Yuor Rating", min_value=1, max_value=5)

class ReviewForm(forms.ModelForm):
    class Meta:
        model = Review
        #fields = ['user_name', 'review-text', 'rating']
        fields = '__all__' # all fields
        #exclude = ['user_name', 'review-text']
        labels = {
            "user_name": "dupa"
        }
        error_messages = {
            "user_name": {
                "required": "dupa2"
            }
        }