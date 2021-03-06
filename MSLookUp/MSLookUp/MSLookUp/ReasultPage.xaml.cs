﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MSLookUp
{
    public partial class ReasultPage : ContentPage
    {
        public String sn1;
        
        public ReasultPage(string number)
        {
            InitializeComponent();

            ListView.ItemsSource = new List<Contact> {
                new Contact{lastName = "Bhatt" , firstName = "Yogin" , studentNumber = "000000000"},       
                new Contact{lastName = "Patel" , firstName = "Tirth" , studentNumber = "000000001"}       
            };

             sn1 = number;
        }


        async  void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            else
                 await DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");

            var contact = e.SelectedItem as Contact;
            //var profilepage = new ProfilePage(contact);
            await Navigation.PushAsync(new ProfilePage(sn1) { BindingContext = contact });
            ListView.SelectedItem = null;
        }
        async void Handle_Activated(object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        async void Handle_Activated1(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }
}
