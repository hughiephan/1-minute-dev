#####################
# Generate Key Pair #
#####################
# variable "key_name" {
#   type = string
#   default = "huy"
# }

# resource "tls_private_key" "example" {
#   algorithm = "RSA"
#   rsa_bits  = 4096
# }

# resource "aws_key_pair" "generated_key" {
#   key_name   = "${var.key_name}"
#   public_key = "${tls_private_key.example.public_key_openssh}"
# }

######################
# Use Local Key Pair #
######################
resource "aws_key_pair" "local-key" {
  key_name   = "huy"
  public_key = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAACAQCobv/3BoBV9zFKlBhS98tGCCfLYBFHSeCDQbmv53akhJN1jyFjmNbKPWGLxytvtNizW7xck8I3zT3JDptQeGkUOx+4iEHQUMuSaI1Ee7MQdUtZ4xwt8Hlpc6EiZIKWL8ClOguwzCYmNkocGlXiuuOJag/yRG6trok6CYFUf2WlB+p1lReWKLToCA5IKabur/iWQhuZA0eZHqIFztyZ3656WGYlq9/LkUqrDP/PKc4PtGVUjAkOlKyM9KWSMW077R2Ku4Oc4FhNnZIrDWOj3cW/L8lawWxvsQ5pvpk/8LeW+asBoZvjvCPkshT5aw7Oi4znudM6ZkbuBxrvZswv3F8T6yeJteaeV1A5iMjCaUMKsoKtckVGOfKjVGB8DqtkQugouGia0j1Z94hy95QTgN1TiE0duIGqO5y3ywrbyk9dIJVobumHJf+tSaA87xOKVxC+j6NDUabUde3HakC4MlUc1GL3dRP/zUCGgpm6M95TAlX4gcIYfbriJ7JA3chFD32s+yfpCRILUaFn10MjOscD5qvchYdf9hd9jVyQRSkstYeTq8Z8CS5jgOVJ0FAa+EBR8cz0f8Csun/9NpM5sQbjTeRRnT3LcwMGFrKRyFKvoy/ln8f4TdkCEaAuDpvMROz/IeWnAuCR3Rq6NcPypwQ1hX/w7Cl2DsvJCrW/Qr2cmQ=="
}

provider "aws" {
  region = "ap-southeast-1" // Singapore
}

###########
# Network #
###########
resource "aws_security_group" "test_sg" {
  name = "test_sg"

  ingress {
    from_port   = 22
    to_port     = 22
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  # Allow outgoing traffic to anywhere.
  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

############
# Instance #
############
resource "aws_instance" "foo" {
  ami           = "ami-0bb4291f4340a8658" # singapore
  instance_type = "t2.micro"
  # key_name      = "${aws_key_pair.generated_key.key_name}"
  key_name = "huy"

  security_groups = [aws_security_group.test_sg.name]

  credit_specification {
    cpu_credits = "unlimited"
  }

  tags = {
    Name = "My Server"
  }
}