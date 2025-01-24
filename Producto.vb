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
