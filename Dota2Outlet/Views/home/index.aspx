<%@ Page Title="" Language="C#" MasterPageFile="~/views/shared/site.master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    default
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<% if (User.Identity.IsAuthenticated) { %>
	<p><b>You are already logged in!</b> Try visiting the
		<%=Html.ActionLink("Members Only", "Index", "User") %>
		area. </p>
	<% } else { %>
	<p>Visit the
		<%=Html.ActionLink("Members Only", "Index", "User") %>
		area to trigger a login. </p>
	<% } %>

</asp:Content>
