using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Xml;
using AmaknaCore.ProtocolBuilder.Profiles;
using AmaknaProxy.ProtocolBuilder.Parsing;
using AmaknaProxy.ProtocolBuilder.Templates;
using AmaknaProxy.ProtocolBuilder.XmlPatterns;
using Microsoft.VisualStudio.TextTemplating;

namespace AmaknaProxy.ProtocolBuilder.Profiles
{
    public class TypesProfile : ParsingProfile
    {
        public override void ExecuteProfile(Parser parser)
        {
            var relativePath = GetRelativePath(parser.Filename);

            string file = Path.Combine(Program.Configuration.Output, OutPutPath, relativePath, Path.GetFileNameWithoutExtension(parser.Filename));
            var xmlType = Program.Configuration.XmlTypesProfile.SearchXmlPattern(Path.GetFileNameWithoutExtension(parser.Filename));

            if (xmlType == null)
                Program.Shutdown(string.Format("File {0} not found", file));

            var engine = new Engine();
            var host = new TemplateHost(TemplatePath);
            host.Session["Type"] = xmlType;
            
            host.Session["Profile"] = this;
            var output = engine.ProcessTemplate(File.ReadAllText(TemplatePath), host);

            foreach (CompilerError error in host.Errors)
            {
                Console.WriteLine(error.ErrorText);
            }

            if (host.Errors.Count > 0)
                Program.Shutdown();

            File.WriteAllText(file + host.FileExtension, TypeFixer.FixType(output));

            Console.WriteLine("Wrote {0}", file + host.FileExtension);
        }
    }
}