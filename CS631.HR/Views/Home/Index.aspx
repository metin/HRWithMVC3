<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid_12">

<style>




</style>

<div class="form">
    <form id="form" name="form" method="post" action="index.html">
        <h1>Sign-up form</h1>
        <p>This is the basic look of my form without table</p>
        <br />
        <div>
            <label>Name
                <span class="small">Add your name</span>
            </label>
            <input type="text" name="name" id="name" />
        </div>
        <div class="clear"></div> 
        <div>
            <label>Email
                <span class="small">Add a valid address</span>
            </label>
            <input type="text" name="email" id="email" />
        </div>
        <div class="clear"></div> 
        <div>
            <label>Password
                <span class="small">Min. size 6 chars</span>
            </label>
            <input type="text" name="password" id="password" />
        </div>
        <div class="clear"></div> 
        <div>
            <button type="submit">Sign-up</button>
            <div class="spacer"></div>
        </div>
    </form>
</div>
    </div>
    
    <div class="clear"></div> 

</asp:Content>
