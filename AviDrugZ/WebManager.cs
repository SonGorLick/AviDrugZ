﻿using AviDrugZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using VRChat.API.Model;
using AviDrugZ.Models.WebModels;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Windows;

namespace AviDrugZ
{
    internal class WebManager
    {
        public static async Task<ObservableCollection<AvatarModel>> getAvatarsByName(string avatarName)
        {
            //Make a HttpWebRequest to the API on klauentec.zapto.org/avatars/avatars.php
            //Get the JSON response
            //Parse the JSON response into a list of Avatar objects
           
            string url = "https://klauentec.zapto.org/avatars/avatars.php";
            //Urlencode avatarName
            string urlEncodedAvatarName = System.Web.HttpUtility.UrlEncode(avatarName);
            url += "?name=" + urlEncodedAvatarName;
            
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync(url);

           // string content = await response.Content.ReadAsStringAsync();

            ObservableCollection<AvatarWeb> webAvatars = await response.Content.ReadFromJsonAsync<ObservableCollection<AvatarWeb>>();
            ObservableCollection<AvatarModel> avatars = new();
            if (webAvatars != null)
            {
               
                foreach (AvatarWeb webAvatar in webAvatars)
                {
                    AvatarModel avatar = new();
                    avatar.AvatarName = webAvatar.AvatarName;
                    avatar.AuthorId = webAvatar.AuthorId;
                    avatar.AuthorName = webAvatar.AuthorName;
                    avatar.Description = webAvatar.Description;
                    avatar.AvatarID = webAvatar.Id;
                    //  avatar.AssetUrl = webAvatar.AssetUrl;

                    if (webAvatar.ImageUrl != null) avatar.ImageUrl = webAvatar.ImageUrl.ToString();
                    if (webAvatar.ThumbnailUrl != null) avatar.ThumbnailUrl = webAvatar.ThumbnailUrl.ToString();
                    //   avatar. = webAvatar.IsPrivate;
                    avatar.QuestSupported = webAvatar.SupportedPlatforms == 3 ? true : false;
                    avatar.Version = webAvatar.Version.ToString();
                    avatar.IsPrivate = webAvatar.IsPrivate == 1 ? true : false;
                    //   avatar.IsDeleted = webAvatar.IsDeleted;
                    avatar.Version = webAvatar.UnityVersion;
                    avatars.Add(avatar);
                }
            }
            return avatars;
                


        }

        public static async Task<ObservableCollection<AvatarModel>> getAvatarsByAuthor(string authorName)
        {
            //Make a HttpWebRequest to the API on klauentec.zapto.org/avatars/avatars.php
            //Get the JSON response
            //Parse the JSON response into a list of Avatar objects

            string url = "https://klauentec.zapto.org/avatars/avatars.php";
            //Urlencode avatarName
            string urlEncodedAvatarName = System.Web.HttpUtility.UrlEncode(authorName);
            url += "?author=" + urlEncodedAvatarName;

            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync(url);

            ObservableCollection<AvatarWeb> webAvatars = await response.Content.ReadFromJsonAsync<ObservableCollection<AvatarWeb>>();
            ObservableCollection<AvatarModel> avatars = new();
            if (webAvatars != null)
            {
                foreach (AvatarWeb webAvatar in webAvatars)
                {
                    AvatarModel avatar = new();
                    avatar.AvatarName = webAvatar.AvatarName;
                    avatar.AuthorId = webAvatar.AuthorId;
                    avatar.AuthorName = webAvatar.AuthorName;
                    avatar.Description = webAvatar.Description;
                    avatar.AvatarID = webAvatar.Id;
                    //  avatar.AssetUrl = webAvatar.AssetUrl;

                    if (webAvatar.ImageUrl != null) avatar.ImageUrl = webAvatar.ImageUrl.ToString();
                    if (webAvatar.ThumbnailUrl != null) avatar.ThumbnailUrl = webAvatar.ThumbnailUrl.ToString();
                    //   avatar. = webAvatar.IsPrivate;
                    avatar.QuestSupported = webAvatar.SupportedPlatforms == 3 ? true : false;
                    avatar.Version = webAvatar.Version.ToString();
                    avatar.IsPrivate = webAvatar.IsPrivate == 1 ? true : false;
                    //   avatar.IsDeleted = webAvatar.IsDeleted;
                    avatar.Version = webAvatar.UnityVersion;
                    avatars.Add(avatar);
                }
            }
            return avatars;


        }

    }
}