<%@ Page Title="" Language="C#" MasterPageFile="~/views/shared/site.master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    default
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% if (ViewData["message"] != null) { %>
	<div style="border: solid 1px red">
		<%= Html.Encode(ViewData["message"].ToString())%>
	</div>
	<% } %>
	<p>You must log in before entering the Members Area: </p>
	<form action="Authenticate?redirect=<%=HttpUtility.UrlEncode(Request.QueryString["redirect"]) %>" method="post">
	    <input type="image" src="../../Content/img/sits_small.png"/>
	</form>

</asp:Content>
