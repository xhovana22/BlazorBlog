#pragma checksum "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\Pages\Components\Forums\AddNewCategoryForm.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f041894668edf67e3f7a8ff3b6221e6074f9470e"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorForum.Areas.Admin.Pages.Components.Forums
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
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
#nullable restore
#line 1 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using BlazorForum.Areas.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using BlazorForum.Areas.Admin.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using BlazorForum.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\_Imports.razor"
using Microsoft.AspNetCore.Mvc.Rendering;

#line default
#line hidden
#nullable disable
    public partial class AddNewCategoryForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "C:\Users\user\Desktop\BlazorForum-master\BlazorForum\Areas\Admin\Pages\Components\Forums\AddNewCategoryForm.razor"
       
    [Parameter] public Action OnCategoryCreated { get; set; }
    [Parameter] public int ForumId { get; set; }
    private Models.ForumCategory category = new Models.ForumCategory();
    private string titleClass { get; set; } = "form-control";
    private string textAreaClass { get; set; } = "mt-2 form-control";
    private string btnVisibility = "d-block";
    private string submitVisibility = "d-none";

    private async Task CreateCategory()
    {
        var newCategory = new Models.ForumCategory()
        {
            Title = category.Title,
            Description = category.Description,
            ForumId = ForumId
        };
        var added = await manageCategories.CreateCategoryAsync(newCategory);

        btnVisibility = "d-inline-block";
        submitVisibility = "d-none";
        category.Title = string.Empty;
        category.Description = string.Empty;

        titleClass = "form-control clear-validation";
        textAreaClass = "mt-2 form-control clear-validation";

        OnCategoryCreated?.Invoke();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IManageForumCategories manageCategories { get; set; }
    }
}
#pragma warning restore 1591
