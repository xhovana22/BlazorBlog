#pragma checksum "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Pages\Components\Forums\ForumCategory.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56a9da50c34a2cb6e085b56ba9d50e8391135cd8"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorForum.Pages.Components.Forums
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using BlazorForum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using BlazorForum.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using BlazorForum.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using Domain.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using BlazorForum.Domain.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using Domain.Utilities.Formatting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using BlazorForum.Pages.Components.BlazorModal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\_Imports.razor"
using BlazorForum.Pages.Components.BlazorModal.Components;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/category/{id:int}/{slug}")]
    public partial class ForumCategory : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 70 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Pages\Components\Forums\ForumCategory.razor"
       
    [Parameter] public int id { get; set; }
    [Parameter] public string slug { get; set; }
    [Parameter] public string CurrentUserId { get; set; }
    private Models.ForumCategory _category;
    private List<Models.ForumTopic> _topics { get; set; }
    private List<TopicPostCount> _postCountList = new List<TopicPostCount>();
    private int _maxCount = 10;
    private string _loadMoreVisibility;

    protected override async Task OnInitializedAsync()
    {
        _category = await manageForumCategories.GetForumCategoryAsync(id);
        _topics = await manageForumTopics.GetApprovedForumTopicsAsync(id);

        if (_maxCount >= _topics.Count)
            _loadMoreVisibility = "d-none";

        _topics = _topics.OrderByDescending(p => p.PostedDate).Take(_maxCount).ToList();
        CurrentUserId = await new Domain.Utilities.Membership.UserInfo(userManager, authStateProvider).GetUserId();
        await AddUserToTopicAsync();

        //await SetTopicsCount();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender)
        {
            await JSRuntime.InvokeVoidAsync("setDocTitle", _category.Title);
        }
    }

    public async void UpdateTopicsAsync()
    {
        _topics = await manageForumTopics.GetApprovedForumTopicsAsync(id);

        if (_maxCount >= _topics.Count)
            _loadMoreVisibility = "d-none";
        else
            _loadMoreVisibility = "d-inline-block";

        _topics = _topics.OrderByDescending(p => p.PostedDate).Take(_maxCount).ToList();

        await AddUserToTopicAsync();
        StateHasChanged();
    }

    public async Task LoadMoreTopicsAsync()
    {
        _maxCount += 10;
        _topics = await manageForumTopics.GetApprovedForumTopicsAsync(id);

        if (_maxCount >= _topics.Count)
            _loadMoreVisibility = "d-none";
        else
            _loadMoreVisibility = "d-inline-block";

        _topics = _topics.OrderByDescending(p => p.PostedDate).Take(_maxCount).ToList();

        await AddUserToTopicAsync();
        StateHasChanged();
    }

    private async Task AddUserToTopicAsync()
    {
        foreach (var topic in _topics)
        {
            var user = await userManager.FindByIdAsync(topic.UserId);
            topic.UserName = user.UserName;
        }
    }

    protected async Task SetTopicsCount()
    {
        var topics = await manageForumTopics.GetApprovedForumTopicsAsync(id);
        
        foreach (var topic in topics)
        {
            var posts = await manageForumPosts.GetApprovedForumPostsAsync(topic.ForumTopicId);
            var postCount = new TopicPostCount
            {
                ParentItemId = topic.ForumTopicId,
                ChildCount = posts.Count
            };
            _postCountList.Add(postCount);
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider authStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<IdentityUser> userManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IManageForumPosts manageForumPosts { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IManageForumTopics manageForumTopics { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IManageForumCategories manageForumCategories { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navManager { get; set; }
    }
}
#pragma warning restore 1591
