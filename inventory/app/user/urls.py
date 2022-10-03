"""
URL mappings for the User API.
"""
from django.urls import path

from user import views


app_name = 'user'


urlpatterns = [
    path('', views.CreateUserView.as_view(), name='create'),
]