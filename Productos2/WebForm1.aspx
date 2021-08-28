<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Productos2.WebForm1" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="./style.css" />
    <title></title>
</head>
<body>
    <nav class="navbar navbar-dark">
        <div class="container-fluid">
            <strong><a href="#" class="navbar-brand">Productos</a></strong>
        </div>
    </nav>
    <main class="container-fluid pt-3">
        <div class="row">
            <div class="col-md-6">
                <div class="products ml-1 mr-1 p-4">
                    <h4 class="font-weight-bold">LISTA DE PRODUCTOS
                    </h4>
                    <form id="form1" runat="server">
                        <div>
                            <div class="form-group mt-2">
                                <asp:TextBox class="form-control" ID="Nombre" runat="server" Placeholder="Nombre del producto"></asp:TextBox>
                            </div>

                            <div class="row mt-2">
                                <div class="col ">
                                    <asp:TextBox class="form-control" ID="Cantidad" Placeholder="Cantidad" type="number" min="0" runat="server"></asp:TextBox>
                                </div>
                                <div class="col ">
                                    <asp:TextBox class="form-control" ID="Precio" Placeholder="Precio(S/.)" type="number" step="0.01" min="0" runat="server"></asp:TextBox>
                                </div>
                            </div>


                            <div class="form-group mt-2">
                                <asp:TextBox class="form-control" ID="Descripcion" Placeholder="Descripción" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>

                            <div class="form-group mt-2">
                                <!-- <asp:TextBox class="form-control" ID="imgURL" Placeholder="Imagen del producto (URL)." runat="server"></asp:TextBox> -->
                                <asp:FileUpload class="form-control" ID="FileUpload1" runat="server" />
                            </div>

                            <div class="d-grid gap-2 mt-2 mb-2">
                                <asp:Button class="btn btn-success btn-block" ID="Add" runat="server" Text="Agregar" OnClick="Add_Click" />
                            </div>

                        </div>
                        <asp:Panel ID="listProducts" runat="server">
                        </asp:Panel>

                    </form>
                </div>
            </div>

            <!-- DETALLES PRODUCTO -->
            <div class="col-md-6">

                <div class="details ml-1 mr-1" id="productDetails" runat="server">
                    <h4 class="font-weight-bold pl-4 pt-4">DETALLES</h4>
                    <div class="row p-4">
                        <div class="col-md-6">
                            <asp:Image class="imgProduct" ID="Image2" ImageUrl="./Upload/default2.jpg" runat="server"/>
                        </div>
                        <div class="col-md-6">
                            <input class="form-control mb-2" type="text" placeholder="Nombre" id="NombreDetalle" runat="server"/>
                            <input class="form-control  mb-2" type="text" placeholder="Cantidad" id="CantidadDetalle" runat="server"/>
                            <input class="form-control  mb-2" type="text" placeholder="Precio" id="PrecioDetalle" runat="server"/>
                            <textarea class="form-control  mb-2" placeholder="Descripción" id="DescripcionDetalle" runat="server"></textarea>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </main>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>
</html>
