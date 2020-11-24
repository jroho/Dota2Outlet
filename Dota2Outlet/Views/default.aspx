<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" AutoEventWireup="true" %>

<script runat="server">
	protected void Page_Load(object sender, EventArgs e) {
		Response.Redirect("~/home/index");
	}
</script>
