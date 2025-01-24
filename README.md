# Project Title: DataGridView
 
 Este proyecto consiste en una aplicacion de venta de productos 
 que agrega los campos decriptivos de un producto al DataGrid 
 para luego hacer el calculo del total a pagar por el cliente.


# Descripcion

 Este proyecto consiste en el desarrollo de una aplicacion que 
 lleva a cabo la venta de una serie de productos que han sido 
 agregados a una Coleccion <List> en el evento Form_Load.
 Luego al buscar a cada producto y colocar la cantidad de unidades
 a llevar por el cliente, se hace click en un boton que agregara 
 los productos al DataGrid para posteriormente hacer el calculo 
 del total a pagar por el cliente por la cantidad de productos 
 que lleva.
 
 # Actualizacion: 23/01/2025
 # Hora: 22:48

Detalles técnicos del proyecto:
Idioma: Visual Basic.NET
Versión del framework: 4.7.2

## Autores

- [@ozzies-code](https://www.github.com/ozzies-code)

## Contribuciones

¡Las contribuciones son siempre bienvenidas!

Consulta `contributing.md` para conocer cómo comenzar.

Por favor, respeta el `código de conducta` de este proyecto.

## Despliegue

Para implementar este proyecto, descargue los archivos del proyecto
del repositorio y el código del proyecto que se encuentra
en el archivo README.md

## 🚀 Acerca de Mi
Soy un apasionado desarrollador fullstack de Venezuela 🇻🇪 y Países Bajos 🇳🇱


🔭 Actualmente estoy trabajando en .NET Framework

🔭 Actualmente estoy trabajando en desarrollo web

🔭 Actualmente estoy trabajando en proyectos de .Console

🔭 Actualmente estoy trabajando en bases de datos .SQL

🌱 Actualmente estoy aprendiendo sobre frameworks, cursos, tutoriales y libros electrónicos

💬 Pregúntame sobre desarrollo de software

📫 Cómo contactarme oswaldojmp.nl@proton.me

👨‍💻 Todos mis proyectos están disponibles en https://developerandtechnologyozziescode.blogspot.com/ (mi sitio web)

📝 Escribo artículos regularmente en Medium.com/Ozzies.Code

    ## 🔗 Links
[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)]( https://developerandtechnologyozziescode.blogspot.com)
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](www.linkedin.com/in/oswaldo-jesús-marín-pagés-ab4499a4)
[![twitter](https://img.shields.io/badge/twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white)](https://twitter.com/ozzies_code)

## Lecciones Aprendidas

- Manejo del DataGrid
- eventos de una Coleccion List
- logica de programacion

## image of the Project

![imagen](https://github.com/user-attachments/assets/5c5669a6-f7bd-409b-a5b2-9cfa48770488)

## Soporte

Para soporte, email oswaldojmp.nl@proton.me

## Pila de tecnología

**Plataforma:** Visual studio 2022

**Lenguaje:** Visual Basic.NET

Codigo del Proyecto:

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

    Public Class Producto

    'Atributoso Miembros de la clase
    'Variables de Clase
    Private codigo As String
    Private descripcion As String
    Private precioU As Double
    Private Shared indiceCodigo As Integer = 1 'Atributo Compartido que automatiza el valor del atributo Codigo

    Public Sub New(ByVal des As String, ByVal pu As Double)

        codigo = "AR00" & indiceCodigo 'Texto + numeros. Inicia con 1/
        indiceCodigo += 1
        descripcion = des
        precioU = pu

    End Sub

    Public ReadOnly Property Codigo_Producto As String

        Get
            Return codigo
        End Get
    End Property

    Public ReadOnly Property Descripcion_Producto As String

        Get
            Return descripcion
        End Get
    End Property

    Public ReadOnly Property Precio_Producto As String

        Get
            Return precioU
        End Get
    End Property


End Class

End Class
