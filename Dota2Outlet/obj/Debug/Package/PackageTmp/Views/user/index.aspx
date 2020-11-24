<%@ Page Title="" Language="C#" MasterPageFile="~/views/shared/site.master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    default
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Members Only Area </h1>
	<p>Congratulations, <b>
		<%=Session["FriendlyIdentifier"] %></b>. You have completed the OpenID login process.
	</p>
	<p>
		<%=Html.ActionLink("Logout", "logout") %>
	</p>

</asp:Content>
