Public Class Form1

    Dim listaproductos As New List(Of Producto) 'Lista de productos


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Se crean los productos
        'Se adhieren los productos a la lista de productos 

        listaproductos.Add(New Producto("ARROZ X 500GR", 1800))
        listaproductos.Add(New Producto("ACEITE X 1000ML", 9800))
        listaproductos.Add(New Producto("ATUN EN LATA MARCA XYZ", 5400))
        listaproductos.Add(New Producto("SALSA DE TOMATE X 500GR", 4300))

        desactivaTextBox() 'ver en la rutina

        'Dim codigo As DataGridViewColumn

        'codigo.HeaderText = "Codigo"
        'codigo.CellTemplate = New DataGridViewTextBoxCell
        'dgvProductos.Columns.Add(codigo)
        'Esto se realizo por las propiedades del DataGridView


    End Sub

    Private Sub limpiaTextBox()

        'Se limpian los TextBox de la interfaz

        txtCodigo.Clear()
        txtDescripcion.Clear()
        txtPrecioU.Clear()
        txtCantidad.Clear()
        txtTotal.Clear()

    End Sub

    Private Sub txtCantidad_LostFocus(sender As Object, e As EventArgs) Handles txtCantidad.LostFocus

        'Se calcula el total de la compra
        'Se valida que la cantidad sea mayor a 0 y el campo no este vacio


        If txtCantidad.Text <> " " And Val(txtCantidad.Text) > 0 Then
            Dim total As Double = Val(txtPrecioU.Text) * Val(txtCantidad.Text)

            txtTotal.Text = total.ToString
        End If
    End Sub

    Private Sub desactivaTextBox()

        'Se desactivan los TextBox de la interfaz

        txtDescripcion.Enabled = False
        txtPrecioU.Enabled = False
        txtTotal.Enabled = False
    End Sub

    Private Sub txtCodigo_LostFocus(sender As Object, e As EventArgs) Handles txtCodigo.LostFocus

        'Se busca el producto en la lista de productos
        'Se muestra la descripcion y el precio del producto en los TextBox
        'Se captura la excepcion si el codigo no existe

        Try
            Dim codigo As String = txtCodigo.Text.ToUpper

            For i = 0 To listaproductos.Count - 1 Step 1
                If codigo.Equals(listaproductos.Item(i).Codigo_Producto) Then

                    txtDescripcion.Text = listaproductos.Item(i).Descripcion_Producto
                    txtPrecioU.Text = listaproductos.Item(i).Precio_Producto
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("El codigo ingresado no existe")
        End Try
    End Sub

    Private Sub dgvProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        'Se agregan los campos a la tabla de productos

        dgvProductos.Rows.Add(txtCodigo.Text, txtDescripcion.Text, txtPrecioU.Text, txtCantidad.Text, txtTotal.Text)


    End Sub

    Private Sub btnVertotales_Click(sender As Object, e As EventArgs) Handles btnVertotales.Click

        'Se calculan los totales de la venta
        'Se recorre la tabla de productos y se suman los totales
        'Se calcula el subtotal, el iva y el total de la venta
        'Se muestran los totales en los TextBox

        Dim total As Double = 0

        For i = 0 To dgvProductos.Rows.Count - 1 Step 1
            total += dgvProductos.Rows.Item(i).Cells.Item(4).Value

        Next

        Dim subtotal As Double = total - (total * 0.19)
        Dim iva As Double = total * 0.19

        txtSubtotal.Text = subtotal.ToString
        txtIva.Text = iva.ToString
        txtTotalVenta.Text = total.ToString
    End Sub
End Class
