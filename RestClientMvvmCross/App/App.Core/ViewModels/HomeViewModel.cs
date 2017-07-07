using Acr.UserDialogs;
using App.Core.Exceptions;
using App.Core.Models;
using App.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace App.Core.ViewModels
{
    class HomeViewModel : MvxViewModel
    {
        private readonly IApiService apiService;
        private readonly IMvxNavigationService navigationService;
        //private readonly IDialogService dialogService;
        private readonly IUserDialogs dialogService;
        private MvxObservableCollection<Post> itemsPosts;
        private Post itemPost;
        private IMvxCommand itemsPostsSelected;

        public HomeViewModel(IApiService apiService, IMvxNavigationService navigationService, /*IDialogService dialogService*/ IUserDialogs dialogService)
        {
            this.apiService = apiService;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            itemsPosts = new MvxObservableCollection<Post>();
        }

        public override void Start()
        {
            base.Start();
            getApiPosts();
        }

        public MvxObservableCollection<Post> ItemsPosts
        {
            get
            {
                return itemsPosts;
            }
            set
            {
                itemsPosts = value;
                RaisePropertyChanged(() => ItemsPosts);
            }
        }

        public Post ItemPost
        {
            get
            {
                return itemPost;
            }
            set
            {
                itemPost = value;
                RaisePropertyChanged(() => ItemPost);
            }
        }

        public IMvxCommand ItemsPostsSelected
        {
            get
            {
                itemsPostsSelected = itemsPostsSelected ?? new MvxCommand<Post>(
                     getApiPost
                );
                return itemsPostsSelected;
            }
        }

        private void getApiPosts()
        {
            dialogService.ShowLoading();

            apiService.GetPosts((List<Post> data, Exception error) =>
            {
                dialogService.HideLoading();

                if (error == null)
                {
                    this.ItemsPosts.Clear();
                    foreach (Post p in data)
                    {
                        this.ItemsPosts.Add(p);
                    }
                }
                else
                {
                    if (error.GetType() == typeof(ApiException))
                    {
                        // TODO
                        dialogService.AlertAsync("API Error!", "Warning", "OK");
                    }
                    else if (error.GetType() == typeof(NetworkException))
                    {
                        // TODO
                    }
                    else if (error.GetType() == typeof(ArgumentNullException))
                    {
                        // TODO
                    }
                }
            });
        }

        private void getApiPost(Post post)
        {
            dialogService.ShowLoading();

            apiService.GetPost((Post data, Exception error) =>
            {
                dialogService.HideLoading();

                if (error == null)
                {
                    ItemPost = data;
                }
                else
                {
                    if (error.GetType() == typeof(ApiException))
                    {
                        // TODO
                    }
                    else if (error.GetType() == typeof(NetworkException))
                    {
                        // TODO
                    }
                    else if (error.GetType() == typeof(ArgumentNullException))
                    {
                        // TODO
                    }
                }
            }, post.Id.ToString());
        }
    }
}
